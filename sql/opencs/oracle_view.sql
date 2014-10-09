----视图

CREATE OR REPLACE VIEW  vw_jReader_top100  as 
	select j.journalID, j.title, j.authorID from 
	(
		(select * from tb_journal 
			order by readerCount desc
		) j
	)
	where rownum <= 100
;/

CREATE OR REPLACE VIEW  vw_jReply_top100  as 
	select j.journalID, j.title, j.authorID from 
	(
		(select * from tb_journal 
			order by replyCount desc
		) j
	)
	where rownum <= 100
;

CREATE OR REPLACE VIEW  vw_uScore_top1000  as 
	select s.userID, s.username, s.score from 
	(
		(select * from tb_user 
			order by score desc
		) j
	)
	where rownum <= 1000
;

CREATE OR REPLACE VIEW  vw_uFromLocal  as 
	select * from tb_user u
	where 
	(
		u.manner = 0
	)
;

CREATE OR REPLACE VIEW  vw_uFromTencent  as 
	select * from tb_user u
	where 
	(
		u.manner = 1
	)
;

CREATE OR REPLACE VIEW  vw_uFromSina  as 
	select * from tb_user u
	where 
	(
		u.manner = 2
	)
;

CREATE OR REPLACE VIEW  vw_uFromRenren  as 
	select * from tb_user u
	where 
	(
		u.manner = 3
	)
;

CREATE OR REPLACE VIEW  vw_uFromFacebook  as 
	select * from tb_user u
	where 
	(
		u.manner = 4
	)
;
