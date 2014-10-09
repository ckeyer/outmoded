
--CONN ADMIN@opencs/manager;
--/

---- tables

CREATE TABLE tb_user
(
 userID NUMBER(9) NOT NULL ,
 username VARCHAR2(20) NOT NULL ,
 password CHAR(32) ,
 manner NUMBER DEFAULT(0) NOT NULL ,
 email varchar2(64) NOT NULL ,
 sex  VARCHAR2(2)  CHECK(sex IN('男' ,'女')) ,
 birth DATE ,
 score number(6) DEFAULT 100 ,
 pic blob ,
 description VARCHAR(256) ,
 journalCount NUMBER DEFAULT(0) NOT NULL ,
 projectCount NUMBER DEFAULT(0) NOT NULL ,
 replylCount NUMBER DEFAULT(0) NOT NULL ,
 friendCount NUMBER DEFAULT(0) NOT NULL ,
 groupCount NUMBER DEFAULT(0) NOT NULL ,
 keyword1 NUMBER(4),
 keyword2 NUMBER(4),
 keyword3 NUMBER(4),
 keyword4 NUMBER(4),
 PRIMARY KEY(userID) VALIDATE
)
TABLESPACE SPUSER
;
/

CREATE TABLE tb_journal
(
 journalID NUMBER(11) NOT NULL ,
 title VARCHAR(64) NOT NULL ,
 authorID NUMBER(9) NOT NULL ,
 pubTime DATE NOT NULL ,
 contentType NUMBER DEFAULT(0) NOT NULL ,
 parentProjID NUMBER(6) ,
 parentGrouID NUMBER(7) ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 readerCount NUMBER DEFAULT(0) NOT NULL ,
 keyword1 NUMBER(4) ,
 keyword2 NUMBER(4) ,
 keyword3 NUMBER(4) ,
 keyword4 NUMBER(4) ,
 PRIMARY KEY(journalID) VALIDATE 
)
TABLESPACE SPUSER
;
/

CREATE TABLE tb_reply
(
 replyID NUMBER(11) NOT NULL ,
 authorID NUMBER(9) NOT NULL ,
 pubTime DATE NOT NULL ,
 contentType NUMBER DEFAULT(0) NOT NULL ,
 parentType NUMBER DEFAULT(0) NOT NULL ,
 parentUserID NUMBER(7) ,
 parentJourID NUMBER(11) ,
 parentReplID NUMBER(11) ,
 parentProjID NUMBER(6) ,
 parentGrouID NUMBER(7) ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 readerCount NUMBER DEFAULT(0) NOT NULL ,
 PRIMARY KEY(replyID) VALIDATE 
)
TABLESPACE SPUSER
;
/

CREATE TABLE tb_project
(
 projectID NUMBER(6) NOT NULL ,
 projectName VARCHAR2(64) NOT NULL ,
 version CHAR(12) ,
 createTime DATE NOT NULL ,
 lastTime DATE ,
 masterID NUMBER(9) NOT NULL ,
 parentProjID NUMBER(6) ,
 description VARCHAR(256) ,
 pic blob ,
 adminCount NUMBER DEFAULT(0) NOT NULL ,
 authorCount NUMBER DEFAULT(0) NOT NULL ,
 childProjCount NUMBER DEFAULT(0) NOT NULL ,
 journalCount NUMBER DEFAULT(0) NOT NULL ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 keyword1 NUMBER(4),
 keyword2 NUMBER(4),
 keyword3 NUMBER(4),
 keyword4 NUMBER(4),
 PRIMARY KEY(projectID) VALIDATE 
)
TABLESPACE SPUSER
;
/


CREATE TABLE tb_group
(
 groupID NUMBER(7) NOT NULL ,
 groupName VARCHAR2(32) NOT NULL ,
 createTime DATE NOT NULL ,
 lastTime DATE ,
 masterID NUMBER(9) NOT NULL ,
 description VARCHAR(256) ,
 adminCount  NUMBER DEFAULT(0) NOT NULL ,
 userCount  NUMBER DEFAULT(0) NOT NULL ,
 projectCount NUMBER DEFAULT(0) NOT NULL ,
 journalCount NUMBER DEFAULT(0) NOT NULL ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 keyword1 NUMBER(4),
 keyword2 NUMBER(4),
 keyword3 NUMBER(4),
 keyword4 NUMBER(4),
 PRIMARY KEY(groupID) VALIDATE 
)
TABLESPACE SPUSER
;
/   

CREATE TABLE tb_keyword
(
 keywordID NUMBER(4) NOT NULL ,
 keywordValue VARCHAR2(24) NOT NULL ,
 typeID NUMBER(4) ,
 PRIMARY KEY(keywordID) VALIDATE 
)
TABLESPACE SPUSER
;
/


ALTER TABLE tb_user ADD CONSTRAINT uq_user_email UNIQUE(email) 
;
/
ALTER TABLE tb_user ADD CONSTRAINT fk_user_keyword1 FOREIGN KEY(keyword1) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_user ADD CONSTRAINT fk_user_keyword2 FOREIGN KEY(keyword2) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_user ADD CONSTRAINT fk_user_keyword3 FOREIGN KEY(keyword3) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_user ADD CONSTRAINT fk_user_keyword4 FOREIGN KEY(keyword4) REFERENCES tb_keyword(keywordID) 
;
/


ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_authorID FOREIGN KEY(authorID) references tb_user(userID) 
;
/
ALTER TABLE tb_journal ADD CONSTRAINT ck_jour_type CHECK(type BETWEEN 0 AND 5) 
;
/
ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_parentProjID FOREIGN KEY(parentProjID) REFERENCES tb_project(projectID) 
;
/
ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_parentgrouID FOREIGN KEY(parentGrouID) REFERENCES tb_group(groupID) 
;
/
ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_keyword1 FOREIGN KEY(keyword1) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_keyword2 FOREIGN KEY(keyword2) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_keyword3 FOREIGN KEY(keyword3) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_keyword4 FOREIGN KEY(keyword4) REFERENCES tb_keyword(keywordID) 
;
/

ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_authorID FOREIGN KEY(authorID) references tb_user(userID) 
;
/
ALTER TABLE tb_reply ADD CONSTRAINT ck_repl_type CHECK(type BETWEEN 0 AND 5) 
;
/
ALTER TABLE tb_reply ADD CONSTRAINT ck_repl_parentType CHECK(parentType BETWEEN 0 AND 5) 
;
/
ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentUserID FOREIGN KEY(parentUserID) references tb_user(userID) 
;
/
ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentJourID FOREIGN KEY(parentJourID) references tb_journal(journalID) 
;
/
ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentReplID FOREIGN KEY(parentReplID) references tb_journal(journalID) 
;
/
ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentProjID FOREIGN KEY(parentProjID) REFERENCES tb_project(projectID) 
;
/
ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentgrouID FOREIGN KEY(parentGrouID) REFERENCES tb_group(groupID) 
;
/

ALTER TABLE tb_project ADD CONSTRAINT fk_proj_masterID FOREIGN KEY(masterID) references tb_user(userID) 
;
/
ALTER TABLE tb_project ADD CONSTRAINT fk_prol_parentProjID FOREIGN KEY(parentProjID) REFERENCES tb_project(projectID) 
;
/
ALTER TABLE tb_project ADD CONSTRAINT fk_prol_keyword1 FOREIGN KEY(keyword1) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_project ADD CONSTRAINT fk_prol_keyword2 FOREIGN KEY(keyword2) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_project ADD CONSTRAINT fk_prol_keyword3 FOREIGN KEY(keyword3) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_project ADD CONSTRAINT fk_prol_keyword4 FOREIGN KEY(keyword4) REFERENCES tb_keyword(keywordID) 
;
/

ALTER TABLE tb_group ADD CONSTRAINT fk_grou_masterID FOREIGN KEY(masterID) references tb_user(userID) 
;
/
ALTER TABLE tb_group ADD CONSTRAINT fk_grou_keyword1 FOREIGN KEY(keyword1) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_group ADD CONSTRAINT fk_grou_keyword2 FOREIGN KEY(keyword2) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_group ADD CONSTRAINT fk_grou_keyword3 FOREIGN KEY(keyword3) REFERENCES tb_keyword(keywordID) 
;
/
ALTER TABLE tb_group ADD CONSTRAINT fk_grou_keyword4 FOREIGN KEY(keyword4) REFERENCES tb_keyword(keywordID) 
;
/


