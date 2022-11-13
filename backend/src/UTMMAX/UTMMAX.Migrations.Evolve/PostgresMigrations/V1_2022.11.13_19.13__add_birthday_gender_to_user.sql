ALTER TABLE "user"
    ADD COLUMN IF NOT EXISTS birthday date,
    ADD COLUMN IF NOT EXISTS gender   int;