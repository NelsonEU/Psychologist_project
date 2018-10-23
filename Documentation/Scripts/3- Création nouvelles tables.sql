CREATE TABLE `prj-jmguay`.`appointments` (
  `appointment_id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `availability_id` INT NOT NULL,
  `confirmed` TINYINT NOT NULL DEFAULT 0,
  `message` VARCHAR(500) NULL,
  `outdated` TINYINT NULL DEFAULT 0,
PRIMARY KEY (`appointment_id`));


CREATE TABLE `prj-jmguay`.`availabilities` (
  `Availability_id` INT NOT NULL AUTO_INCREMENT,
  `schedule` DATETIME NOT NULL,
  PRIMARY KEY (`Availability_id`));
  
  
ALTER TABLE appointments ADD FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE appointments ADD FOREIGN KEY (availability_id) REFERENCES availabilities(availability_id);

  
  
  