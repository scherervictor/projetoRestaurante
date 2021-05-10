CREATE TABLE IF NOT EXISTS restaurant (
	Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(300) NOT NULL
);

CREATE TABLE IF NOT EXISTS vote (
	Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    RestaurantId BIGINT NOT NULL,
	ProfessionalId BIGINT NOT NULL,
    Timestamp DATETIME NOT NULL,
    CONSTRAINT FK_vote_Restaurant FOREIGN KEY (RestaurantId) REFERENCES restaurant(Id)
);

CREATE TABLE IF NOT EXISTS winner (
	Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    RestaurantId BIGINT NOT NULL,
	Timestamp DATETIME NOT NULL,
    CONSTRAINT FK_winner_Restaurant FOREIGN KEY (RestaurantId) REFERENCES restaurant(Id)
);


INSERT INTO restaurant (Nome) VALUES 
("Madero"),
("McDonalds"),
("Sushito"),
("BurgerKing"),
("Vó Zilda"),
("Don Peligroso"),
("Churrascaria"),
("Bobs"),
("Pizza");