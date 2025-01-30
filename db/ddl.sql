-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`user` (
  `userID` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Type` VARCHAR(45) NOT NULL,
  `Blocked` TINYINT NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE INDEX `userID_UNIQUE` (`userID` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`policy`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`policy` (
  `policyID` INT NOT NULL AUTO_INCREMENT,
  `policy_name` VARCHAR(45) NOT NULL,
  `Price` DECIMAL(7,2) NOT NULL,
  `Type` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`policyID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`transaction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`transaction` (
  `transactionID` INT NOT NULL AUTO_INCREMENT,
  `user_userID` INT NOT NULL,
  `policy_policyID` INT NOT NULL,
  PRIMARY KEY (`transactionID`),
  INDEX `fk_transaction_user1_idx` (`user_userID` ASC) VISIBLE,
  INDEX `fk_transaction_policy1_idx` (`policy_policyID` ASC) VISIBLE,
  CONSTRAINT `fk_transaction_user1`
    FOREIGN KEY (`user_userID`)
    REFERENCES `mydb`.`user` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaction_policy1`
    FOREIGN KEY (`policy_policyID`)
    REFERENCES `mydb`.`policy` (`policyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
