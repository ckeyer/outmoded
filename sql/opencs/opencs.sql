-- For mysql

-- set character
set character_set_client=utf8;
set character_set_connection=utf8;
set character_set_database=utf8;
set character_set_results=utf8;
set character_set_server=utf8;

-- create databases
CREATE database db_snowy CHARACTER SET utf8 collate utf8_general_ci;

-- create users
CREATE USER 'snowy'@'%' IDENTIFIED BY 'snower';
GRANT select,insert,updatetime,delete ON db_snowy.* TO snowy;


--CONN ADMIN@opencsmanager;
--
use db_snowy;
---- tables
-- 用户表:
DROP TABLE IF EXISTS 'tb_user';
CREATE TABLE tb_user
(
 id NUMBER(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
 username VARCHAR2(64) NOT NULL ,
 password CHAR(64) NOT NULL AUTO_INCREMENT,
 salt CHAR(8) NOT NULL, 
 email varchar2(64) NOT NULL ,
 nickname text ,
 sex  VARCHAR2(2)  CHECK(sex IN('男' ,'女')) ,
 birth datetime ,
 headPic longblob ,
 description text ,
 care varchar(256),
 created datetime DEFAULT NULL,
 updated datetime DEFAULT NULL,

 role int(11) DEFAULT NULL,
 balance int(11) DEFAULT NULL,
 reputation int(11) DEFAULT(100) NULL,
 journal_count NUMBER DEFAULT(0) NOT NULL ,
 project_count NUMBER DEFAULT(0) NOT NULL ,
 replyl_count NUMBER DEFAULT(0) NOT NULL ,
 friend_count NUMBER DEFAULT(0) NOT NULL ,
 group_count NUMBER DEFAULT(0) NOT NULL ,
 weibo text,
 github text,
 douban text
)
ENGINE=InnoDB  AUTO_INCREMENT = 10000 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS 'tb_group';
CREATE TABLE tb_group
(
 id NUMBER(11) NOT NULL AUTO_INCREMENT,
 groupname VARCHAR2(64) NOT NULL ,
 create_time datetime NOT NULL ,
 last-time datetime ,
 master_id NUMBER(11) NOT NULL ,
 description VARCHAR(256) ,
 admin_count  NUMBER DEFAULT(0) NOT NULL ,
 user_count  NUMBER DEFAULT(0) NOT NULL ,
 topic_count NUMBER DEFAULT(0) NOT NULL ,
 reply_count NUMBER DEFAULT(0) NOT NULL ,
 keyword text,
 PRIMARY KEY(id) 
)
ENGINE=InnoDB  AUTO_INCREMENT = 10000 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS 'tb_topic';
CREATE TABLE tb_topic (
  id int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  title text,
  author_id int(11) NOT NULL,
  content text,
  status int(11) DEFAULT NULL,
  created datetime DEFAULT NULL,
  updated datetime DEFAULT NULL,
  node_id int(11) DEFAULT NULL,
  reply_count int(11) DEFAULT NULL,
  scan_count int(11) DEFAULT NULL,
  collect_count int(11) DEFAULT NULL, -- 被收藏数
  last_replied_time datetime DEFAULT NULL,
  up_vote int(11) DEFAULT NULL,
  down_vote int(11) DEFAULT NULL,
  last_touched datetime DEFAULT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=10000 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS 'tb_reply';
CREATE TABLE tb_reply (
  id int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  topic_id int(11) DEFAULT NULL,
  reply_id int(11) DEFAULT NULL,
  author_id int(11) DEFAULT NULL,
  content text,
  created datetime DEFAULT NULL,
  updated datetime DEFAULT NULL,
  up_vote int(11) DEFAULT NULL,
  down_vote int(11) DEFAULT NULL,
  last_touched datetime DEFAULT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=10000 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS 'tb_notification';
CREATE TABLE tb_notification (
  id int(11) NOT NULL AUTO_INCREMENT,
  author_id int(11) NOT NULL,
  content text,
  status int(11) DEFAULT NULL,
  involved_type int(11) DEFAULT NULL,
  involved_user_id int(11) DEFAULT NULL,
  involved_topic_id int(11) DEFAULT NULL,
  involved_reply_id int(11) DEFAULT NULL,
  trigger_user_id int(11) DEFAULT NULL,
  occurrence_time datetime DEFAULT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=255 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS 'tb_node';
CREATE TABLE tb_node (
  id int(11) NOT NULL AUTO_INCREMENT,
  name text,
  description text,
  introduction text,
  topic_count int(11) DEFAULT NULL,
  group_count int(11) DEFAULT NULL,
  user_count int(11) DEFAULT NULL,
  PRIMARY KEY (id)
) 
ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;



DROP TABLE IF EXISTS 'tb_favorite';
CREATE TABLE tb_favorite (
  id int(11) NOT NULL AUTO_INCREMENT,
  owner_user_id int(11) DEFAULT NULL,
  involved_type int(11) DEFAULT NULL,
  involved_topic_id int(11) DEFAULT NULL,
  involved_reply_id int(11) DEFAULT NULL,
  created datetime DEFAULT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;



DROP TABLE IF EXISTS 'notification';
CREATE TABLE notification (
  id int(11) NOT NULL AUTO_INCREMENT,
  content text,
  status int(11) DEFAULT NULL,
  involved_type int(11) DEFAULT NULL,
  involved_user_id int(11) DEFAULT NULL,
  involved_topic_id int(11) DEFAULT NULL,
  involved_reply_id int(11) DEFAULT NULL,
  trigger_user_id int(11) DEFAULT NULL,
  occurrence_time datetime DEFAULT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=255 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS 'plane';
CREATE TABLE plane (
  id int(11) NOT NULL AUTO_INCREMENT,
  name text,
  created text,
  updated text,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;


CREATE TRIGGER topic_delete_trigger BEFORE DELETE ON topic FOR EACH ROW BEGIN
        DELETE FROM reply WHERE reply.topic_id = OLD.id;
        DELETE FROM notification WHERE notification.involved_topic_id = OLD.id;
    END;
 ;;
delimiter ;

DROP TABLE IF EXISTS 'transaction';
CREATE TABLE transaction (
  id int(11) NOT NULL AUTO_INCREMENT,
  type int(11) DEFAULT NULL,
  reward int(11) DEFAULT NULL,
  user_id int(11) DEFAULT NULL,
  current_balance int(11) DEFAULT NULL,
  involved_user_id int(11) DEFAULT NULL,
  involved_topic_id int(11) DEFAULT NULL,
  involved_reply_id int(11) DEFAULT NULL,
  occurrence_time text,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;





CREATE TABLE tb_journal
(
 journalID NUMBER(11) AUTO_INCREMENT PRIMARY KEY,
 title VARCHAR(64) NOT NULL ,
 authorID NUMBER(9) NOT NULL ,
 pubTime datetime NOT NULL ,
 contentType NUMBER DEFAULT(0) NOT NULL ,
 parentProjID NUMBER(6) ,
 parentGrouID NUMBER(7) ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 readerCount NUMBER DEFAULT(0) NOT NULL ,
 keyword1 NUMBER(4) ,
 keyword2 NUMBER(4) ,
 keyword3 NUMBER(4) ,
 keyword4 NUMBER(4) 
)
TABLESPACE SPUSER
;


CREATE TABLE tb_reply
(
 replyID NUMBER(11) NOT NULL AUTO_INCREMENT,
 authorID NUMBER(9) NOT NULL ,
 pubTime datetime NOT NULL ,
 contentType NUMBER DEFAULT(0) NOT NULL ,
 parentType NUMBER DEFAULT(0) NOT NULL ,
 parentUserID NUMBER(7) ,
 parentJourID NUMBER(11) ,
 parentReplID NUMBER(11) ,
 parentProjID NUMBER(6) ,
 parentGrouID NUMBER(7) ,
 replyCount NUMBER DEFAULT(0) NOT NULL ,
 readerCount NUMBER DEFAULT(0) NOT NULL ,
 PRIMARY KEY(replyID) VALIdatetime 
)
TABLESPACE SPUSER
;






CREATE TABLE tb_project
(
 id NUMBER(6) NOT NULL AUTO_INCREMENT,
 projectname VARCHAR2(64) NOT NULL ,
 version CHAR(12) ,
 createTime datetime NOT NULL ,
 lastTime datetime ,
 master_id NUMBER(9) NOT NULL ,
 parentProj_id NUMBER(6) ,
 description VARCHAR(256) ,
 logo_pic longblob ,
 admin_count NUMBER DEFAULT(0) NOT NULL ,
 author_count NUMBER DEFAULT(0) NOT NULL ,
 childProj_count NUMBER DEFAULT(0) NOT NULL ,
 journal_count NUMBER DEFAULT(0) NOT NULL ,
 reply_count NUMBER DEFAULT(0) NOT NULL ,
 keyword text,
 PRIMARY KEY(id) 
)
ENGINE=InnoDB  AUTO_INCREMENT = 10000 DEFAULT CHARSET=utf8;

   

CREATE TABLE tb_keyword
(
 keywordID NUMBER(4) NOT NULL AUTO_INCREMENT,
 keywordValue VARCHAR2(24) NOT NULL ,
 typeID NUMBER(4) ,
 PRIMARY KEY(keywordID) VALIdatetime 
)
TABLESPACE SPUSER
;



ALTER TABLE tb_user ADD CONSTRAINT uq_user_email UNIQUE(email) 
;

ALTER TABLE tb_user ADD CONSTRAINT fk_user_keyword1 FOREIGN KEY(keyword1) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_user ADD CONSTRAINT fk_user_keyword2 FOREIGN KEY(keyword2) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_user ADD CONSTRAINT fk_user_keyword3 FOREIGN KEY(keyword3) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_user ADD CONSTRAINT fk_user_keyword4 FOREIGN KEY(keyword4) REFERENCES tb_keyword(keywordID) 
;



ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_authorID FOREIGN KEY(authorID) references tb_user(userID) 
;

ALTER TABLE tb_journal ADD CONSTRAINT ck_jour_type CHECK(type BETWEEN 0 AND 5) 
;

ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_parentProjID FOREIGN KEY(parentProjID) REFERENCES tb_project(projectID) 
;

ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_parentgrouID FOREIGN KEY(parentGrouID) REFERENCES tb_group(groupID) 
;

ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_keyword1 FOREIGN KEY(keyword1) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_keyword2 FOREIGN KEY(keyword2) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_keyword3 FOREIGN KEY(keyword3) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_journal ADD CONSTRAINT fk_jour_keyword4 FOREIGN KEY(keyword4) REFERENCES tb_keyword(keywordID) 
;


ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_authorID FOREIGN KEY(authorID) references tb_user(userID) 
;

ALTER TABLE tb_reply ADD CONSTRAINT ck_repl_type CHECK(type BETWEEN 0 AND 5) 
;

ALTER TABLE tb_reply ADD CONSTRAINT ck_repl_parentType CHECK(parentType BETWEEN 0 AND 5) 
;

ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentUserID FOREIGN KEY(parentUserID) references tb_user(userID) 
;

ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentJourID FOREIGN KEY(parentJourID) references tb_journal(journalID) 
;

ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentReplID FOREIGN KEY(parentReplID) references tb_journal(journalID) 
;

ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentProjID FOREIGN KEY(parentProjID) REFERENCES tb_project(projectID) 
;

ALTER TABLE tb_reply ADD CONSTRAINT fk_repl_parentgrouID FOREIGN KEY(parentGrouID) REFERENCES tb_group(groupID) 
;


ALTER TABLE tb_project ADD CONSTRAINT fk_proj_masterID FOREIGN KEY(masterID) references tb_user(userID) 
;

ALTER TABLE tb_project ADD CONSTRAINT fk_prol_parentProjID FOREIGN KEY(parentProjID) REFERENCES tb_project(projectID) 
;

ALTER TABLE tb_project ADD CONSTRAINT fk_prol_keyword1 FOREIGN KEY(keyword1) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_project ADD CONSTRAINT fk_prol_keyword2 FOREIGN KEY(keyword2) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_project ADD CONSTRAINT fk_prol_keyword3 FOREIGN KEY(keyword3) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_project ADD CONSTRAINT fk_prol_keyword4 FOREIGN KEY(keyword4) REFERENCES tb_keyword(keywordID) 
;


ALTER TABLE tb_group ADD CONSTRAINT fk_grou_masterID FOREIGN KEY(masterID) references tb_user(userID) 
;

ALTER TABLE tb_group ADD CONSTRAINT fk_grou_keyword1 FOREIGN KEY(keyword1) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_group ADD CONSTRAINT fk_grou_keyword2 FOREIGN KEY(keyword2) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_group ADD CONSTRAINT fk_grou_keyword3 FOREIGN KEY(keyword3) REFERENCES tb_keyword(keywordID) 
;

ALTER TABLE tb_group ADD CONSTRAINT fk_grou_keyword4 FOREIGN KEY(keyword4) REFERENCES tb_keyword(keywordID) 
;




