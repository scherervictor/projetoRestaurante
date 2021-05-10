using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities;
using TheRestaurant.Domain.Interfaces.Repository;
using TheRestaurant.Infra.Configuration;

namespace TheRestaurant.Infra.Repositories
{
    public class MySQLRestaurantRepository : IRestaurantRepository
    {
        private readonly MySqlConnection _mySqlConnection;
        private readonly DateTime _dayLunchRule = (DateTime.Now.Date).AddHours(12);
        private readonly DateTime _dayBeforeRule = (DateTime.Now.AddDays(-1).Date).AddHours(12).AddSeconds(1);

        public MySQLRestaurantRepository(MySQLConfiguration configuration)
        {
            _mySqlConnection = new MySqlConnection(configuration.ConnectionString);
            _mySqlConnection.Open();
        }

        public bool AlreadyVoted(Vote vote)
        {
            var result = _mySqlConnection.Query<Vote>(@"
                SELECT 
                    Id
                FROM 
                    vote
                WHERE
                    ProfessionalId = @ProfessionalId AND
                    Timestamp < @DayLunch AND
                    Timestamp > @DayBefore
            ",
            new
            {
                RestaurantId = vote.Restaurant.Id,
                ProfessionalId = vote.Professional.Id,
                DayLunch = _dayLunchRule,
                DayBefore = _dayBeforeRule,
            });

            return result.Any();
            
        }

        public Winner GetLogWinner(long restaurantId)
        {
            var result = _mySqlConnection.Query<Winner, Restaurant, Winner>(@"
                SELECT 
                    Id,
                    Timestamp,
                    RestaurantId AS Id
                FROM 
                    winner
                WHERE
                    RestaurantId = @RestaurantId
            ",
            (v, r) =>
            {
                v.SetRestaurant(r);

                return v;
            }
            ,
            new
            {
                RestaurantId = restaurantId,
            });

            return result.FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetWinnterRestaurant()
        {
            var result = _mySqlConnection.Query<Restaurant>(@"
                SELECT 
                    v.RestaurantId AS Id, r.Name, COUNT(*) as count
                FROM 
                    vote as v
                INNER JOIN restaurant as r ON r.Id = v.RestaurantId
                WHERE
                    Timestamp < @DayLunch AND
                    Timestamp > @DayBefore
                GROUP BY v.RestaurantId, r.Name
                ORDER BY count DESC
            ",
            new
            {
                DayLunch = _dayLunchRule,
                DayBefore = _dayBeforeRule,
            });

            return result;
        }

        public void LogWinnerRestaurant(Restaurant restaurant)
        {
            _mySqlConnection.Execute(@"
                INSERT INTO winner (RestaurantId, Timestamp)
                VALUES (@RestaurantId, @Timestamp)
            ",
            new
            {
                RestaurantId = restaurant.Id,
                Timestamp = DateTime.Now
            });            
        }

        public bool RestaurantExists(Restaurant restaurant)
        {
            var result = _mySqlConnection.Query<Restaurant>(@"
                SELECT 
                    Id
                FROM 
                    restaurant
                WHERE
                    Id = @Id
            ",
            new
            {
                Id = restaurant.Id
            });

            return result.Any();
        }

        public async Task VoteRestaurant(Vote vote)
        {            
            await _mySqlConnection.QueryAsync<Vote>(@"
                INSERT INTO vote (RestaurantId, ProfessionalId, Timestamp)
                VALUES (@RestaurantId, @ProfessionalId, @Timestamp)
            ",
            new
            {
                RestaurantId = vote.Restaurant.Id,
                ProfessionalId = vote.Professional.Id,
                Timestamp = DateTime.Now
            });
        }
    }
}
