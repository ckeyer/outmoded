
CREATE  TABLESPACE SPUSER 
  DATAFILE '/oracle/app/oracle/oradata/opencs/spUser' 
      SIZE 100M  REUSE AUTOEXTEND ON NEXT 10M MAXSIZE 500M 
  LOGGING 
  EXTENT MANAGEMENT LOCAL 
  SEGMENT SPACE MANAGEMENT AUTO
 ;

CREATE TEMPORARY TABLESPACE temp_cs1
  TEMPFILE '/oracle/app/oracle/oradata/opencs/tmp_cs1' 
       SIZE 100M  REUSE 
 UNIFORM SIZE 128K
;
 
CREATE ROLE rlOpDBA
 IDENTIFIED BY manager
;

GRANT CREATE SESSION TO rlOpDBA;
GRANT CREATE TABLE TO rlOpDBA;
GRANT CREATE VIEW TO rlOpDBA;
GRANT CREATE TYPE TO rlOpDBA;
GRANT CREATE ANY INDEX TO rlOpDBA;
GRANT CREATE TRIGGER TO rlOpDBA;
GRANT CREATE SEQUENCE TO rlOpDBA;
GRANT CREATE CLUSTER TO rlOpDBA;

CREATE USER admin
    IDENTIFIED BY manager
    PROFILE "DEFAULT"
    DEFAULT TABLESPACE SPUSER
;
ALTER USER admin QUOTA  50M ON SPUSER;
GRANT rlOpDBA to admin;

CONN ADMIN@opencs/manager;


CREATE TABLE tb_user
(
 userID NUMBER(9) NOT NULL ,
 username VARCHAR2(20) NOT NULL ,
 password CHAR(32) ,
 manner NUMBER DEFAULT(0) NOT NULL ,
 email varchar2(64) NOT NULL ,
 sex  VARCHAR2(2)  CHECK (sex IN('男' ,'女')) ,
 birth DATE ,
 score number(6) DEFAULT 100 ,
 pic blob(128*1024) ,
 journalCount NUMBER DEFAULT(0) NOT NULL ,
 projectCount NUMBER DEFAULT(0) NOT NULL ,
 replylCount NUMBER DEFAULT(0) NOT NULL ,
 friendCount NUMBER DEFAULT(0) NOT NULL ,
 groupCount NUMBER DEFAULT(0) NOT NULL ,
 PRIMARY KEY (userID) VALIDATE
)
TABLESPACE SPUSER
;

CREATE TABLE tb_journal
(
 journalID NUMBER(11) NOT NULL ,
 title VARCHAR(64) NOT NULL ,
 authorID NUMBER(9) NOT NULL ,
 pubTime TIMESTAMP NOT NULL ,
 type NUMBER DEFAULT(0) NOT NULL ,
 parentProjID NUMBER(6) ,
 parentGrouID NUMBER(7) ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 readerCount NUMBER DEFAULT(0) NOT NULL ,
 keyWord1 VARCHAR2(24) ,
 keyWord2 VARCHAR2(24) ,
 keyWord3 VARCHAR2(24) ,
 keyWord4 VARCHAR2(24) ,
 PRIMARY KEY (journalID) VALIDATE ,
)
;

CREATE TABLE tb_reply
(
 replyID NUMBER(11) NOT NULL ,
 pubTime TIMESTAMP NOT NULL ,
 authorID NUMBER(9) NOT NULL ,
 type NUMBER DEFAULT(0) NOT NULL ,
 parentType NUMBER DEFAULT(0) NOT NULL ,
 parentUserID NUMBER(7) ,
 parentJourID NUMBER(11) ,
 parentReplID NUMBER(11) ,
 parentProjID NUMBER(6) ,
 parentGrouID NUMBER(7) ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 chickCount NUMBER DEFAULT(0) NOT NULL ,
 PRIMARY KEY (replyID) VALIDATE ,
)
;

CREATE TABLE tb_project
(
 projectID NUMBER(6) NOT NULL ,
 projectName VARCHAR2(32) NOT NULL ,
 version CHAR(12) ,
 createTime TIMESTAMP NOT NULL ,
 lastTime TIMESTAMP ,
 masterID NUMBER(9) NOT NULL ,
 parentProjID NUMBER(6) ,
 pic blob(128*1024) ,
 adminCount NUMBER DEFAULT(0) NOT NULL ,
 userCount NUMBER DEFAULT(0) NOT NULL ,
 childProjCount NUMBER DEFAULT(0) NOT NULL ,
 journalCount NUMBER DEFAULT(0) NOT NULL ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 keyWord1 VARCHAR2(24) ,
 keyWord2 VARCHAR2(24) ,
 keyWord3 VARCHAR2(24) ,
 keyWord4 VARCHAR2(24) ,
 PRIMARY KEY (projectID) VALIDATE ,
)
;


CREATE TABLE tb_group
(
 groupID NUMBER(7) NOT NULL ,
 groupName VARCHAR2(32) NOT NULL ,
 createTime TIMESTAMP NOT NULL ,
 lastTime TIMESTAMP ,
 masterID NUMBER(9) NOT NULL ,
 adminCount  NUMBER DEFAULT(0) NOT NULL ,
 userCount  NUMBER DEFAULT(0) NOT NULL ,
 projectCount NUMBER DEFAULT(0) NOT NULL ,
 journalCount NUMBER DEFAULT(0) NOT NULL ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 keyWord1 VARCHAR2(24) ,
 keyWord2 VARCHAR2(24) ,
 keyWord3 VARCHAR2(24) ,
 keyWord4 VARCHAR2(24) ,
 PRIMARY KEY (groupID) VALIDATE ,
)
;


ALTER TABLE tb_journal CONSTRAINT fk_jour_authorID FOREIGN KEY (authorID) references tb_user(userID) 
;
ALTER TABLE tb_journal CONSTRAINT ck_jour_type CHECK (type BETWEEN 0 AND 5) 
;
ALTER TABLE tb_journal CONSTRAINT fk_jour_parentProjID FOREIGN KEY (parentProjID) REFERENCES tb_project(projectID) 
;
ALTER TABLE tb_journal CONSTRAINT fk_jour_parentgrouID FOREIGN KEY (parentGrouID) REFERENCES tb_group(groupID) 
;

ALTER TABLE tb_reply CONSTRAINT fk_repl_authorID FOREIGN KEY (authorID) references tb_user(userID) 
;
ALTER TABLE tb_reply CONSTRAINT ck_repl_type CHECK (type BETWEEN 0 AND 5) 
;
ALTER TABLE tb_reply CONSTRAINT ck_repl_parentType CHECK (parentType BETWEEN 0 AND 5) 
;
ALTER TABLE tb_reply CONSTRAINT fk_repl_parentUserID FOREIGN KEY (parentUserID) references tb_user(userID) 
;
ALTER TABLE tb_reply CONSTRAINT fk_repl_parentJoutID FOREIGN KEY (parentJoutID) references tb_journal(journalID) 
;
ALTER TABLE tb_reply CONSTRAINT fk_repl_parentReplID FOREIGN KEY (parentReplID) references tb_journal(journalID) 
;
ALTER TABLE tb_reply CONSTRAINT fk_repl_parentProjID FOREIGN KEY (parentProjID) REFERENCES tb_project(projectID) 
;
ALTER TABLE tb_reply CONSTRAINT fk_repl_parentgrouID FOREIGN KEY (parentGrouID) REFERENCES tb_group(groupID) 
;

ALTER TABLE tb_project CONSTRAINT fk_proj_masterID FOREIGN KEY (masterID) references tb_user(userID) 
;
ALTER TABLE tb_project CONSTRAINT fk_prol_parentProjID FOREIGN KEY (parentProjID) REFERENCES tb_project(projectID) 
;

ALTER TABLE tb_group CONSTRAINT fk_grou_masterID FOREIGN KEY (masterID) references tb_user(userID) 
;





----创建序列
create sequence sq_userID
increment by 1  
start with 100000000
nomaxvalue
nominvalue
nocache

create sequence sq_journalID
increment by 1  
start with 10000000000
nomaxvalue
nominvalue
nocache

create sequence sq_groupID
increment by 1  
start with 1000000
nomaxvalue
nominvalue
nocache

create sequence sq_projectID
increment by 1  
start with 100000
nomaxvalue
nominvalue
nocache

----创建触发器
----逻辑主键的自动填充
create or  replace trigger tr_userID
before insert on tb_user
for each row
begin
select sq_userID.nextval into :new.userID from dual;
end;

create or  replace trigger tr_journalID
before insert on tb_journal
for each row
begin
select sq_journalID.nextval into :new.journalID from dual;
end;

create or  replace trigger tr_replyID
before insert on tb_reply
for each row
begin
select sq_journalID.nextval into :new.replyID from dual;
end;

create or  replace trigger tr_projectID
before insert on tb_project
for each row
begin
select sq_projectID.nextval into :new.projectID from dual;
end;

create or  replace trigger tr_groupID
before insert on tb_group
for each row
begin
select sq_groupID.nextval into :new.groupID from dual;
end;





insert into tb_user(username ,email) values('wcj' ,'cjstudio@yeah.net')
insert into tb_user(username ,email) values('cjstudio' ,'cjstudio@yeah.net')

create index so_useremail on tb_user (email) TABLESPACE SPUSER;










CREATE OR REPLACE FUNCTION MD5(
passwd IN VARCHAR2)
RETURN VARCHAR2
IS
retval varchar2(32);
BEGIN
retval := utl_raw.cast_to_raw(DBMS_OBFUSCATION_TOOLKIT.MD5(INPUT_STRING => passwd)) ;
RETURN retval;
END;
 
select md5('fuck') from dual;
