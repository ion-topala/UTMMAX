CREATE TABLE public."user"
(
    id             INTEGER PRIMARY KEY      NOT NULL,
    first_name     varchar(200)             NOT NULL,
    last_name      varchar(200)             NOT NULL,
    email          text                     NOT NULL,
    password_hash  text                     NOT NULL,
    created_on_utc timestamp with time zone NOT NULL,
    updated_on_utc timestamp with time zone NOT NULL
);
