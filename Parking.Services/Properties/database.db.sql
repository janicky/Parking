BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `visits` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`start_date`	INTEGER NOT NULL,
	`end_date`	INTEGER,
	`payment`	INTEGER,
	`finished`	BLOB,
	`vehicle_id`	TEXT NOT NULL,
	`payment_id`	INTEGER
);
CREATE TABLE IF NOT EXISTS `vehicles` (
	`id`	TEXT NOT NULL UNIQUE,
	`model`	INTEGER NOT NULL,
	PRIMARY KEY(`id`)
);
CREATE TABLE IF NOT EXISTS `payments` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`value`	REAL NOT NULL,
	`date`	INTEGER NOT NULL
);
COMMIT;