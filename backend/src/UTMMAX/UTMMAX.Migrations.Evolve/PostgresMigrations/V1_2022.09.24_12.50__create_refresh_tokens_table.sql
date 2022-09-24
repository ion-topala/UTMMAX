CREATE TABLE public.refresh_token
(
    id            serial primary key,
    refresh_token character varying(400),
    expires_time  timestamp with time zone NOT NULL,
    user_id       int,
    CONSTRAINT user_id_fkey
        FOREIGN KEY (user_id)
            REFERENCES public.user (id)
            ON DELETE CASCADE
);