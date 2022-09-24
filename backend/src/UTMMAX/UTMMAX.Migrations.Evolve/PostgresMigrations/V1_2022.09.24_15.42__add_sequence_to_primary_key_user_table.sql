CREATE SEQUENCE user_id_seq MINVALUE 1;

ALTER TABLE public."user"
    ALTER id SET DEFAULT nextval('user_id_seq');

ALTER SEQUENCE user_id_seq OWNED BY public."user".id;
