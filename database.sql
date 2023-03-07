ALTER TABLE "public"."jwe_project_person" DROP CONSTRAINT "FK_jwe_project_person_project_id";
ALTER TABLE "public"."jwe_project_person" DROP CONSTRAINT "FK_jwe_person_project_person_id";
DROP TABLE IF EXISTS "public"."jwe_project";
DROP TABLE IF EXISTS "public"."jwe_person";
DROP TABLE IF EXISTS "public"."jwe_project_person";
CREATE TABLE "public"."jwe_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "jwe_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."jwe_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "jwe_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."jwe_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "jwe_project_person_pkey" PRIMARY KEY ("id")
);
INSERT INTO "public"."jwe_project" ("project_name") VALUES ('Exempelprojekt'); -- First example project 
INSERT INTO "public"."jwe_person" ("person_name") VALUES ('Harald'); -- First example user 
INSERT INTO "public"."jwe_project_person" ("project_id", "person_id", "hours") VALUES (5, 8, 6); -- First example report 
ALTER TABLE "public"."jwe_project_person" ADD CONSTRAINT "FK_jwe_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."jwe_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."jwe_project_person" ADD CONSTRAINT "FK_jwe_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."jwe_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;