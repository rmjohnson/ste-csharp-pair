CREATE TABLE surveys (
	id BIGINT NOT NULL AUTO_INCREMENT,
	title VARCHAR(255) NOT NULL,

	PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE questions (
	id BIGINT NOT NULL AUTO_INCREMENT,
	survey_id BIGINT NOT NULL,
	prompt VARCHAR(255) NOT NULL,

	PRIMARY KEY(id),
	FOREIGN KEY (survey_id) REFERENCES surveys(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE survey_responses (
	id BIGINT NOT NULL AUTO_INCREMENT,
	survey_id BIGINT NOT NULL,
	customer_name VARCHAR(255) NOT NULL,
	customer_email VARCHAR(255) NOT NULL,
	
	PRIMARY KEY (id),
	FOREIGN KEY (survey_id) REFERENCES surveys(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE question_responses (
	id BIGINT NOT NULL AUTO_INCREMENT,
	survey_response_id BIGINT NOT NULL,
	question_id BIGINT NOT NULL,
	response TEXT NOT NULL,
	
	PRIMARY KEY (id),
	FOREIGN KEY (survey_response_id) REFERENCES survey_responses(id),
	FOREIGN KEY (question_id) REFERENCES questions(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;