

CREATE OR REPLACE PACKAGE admin.pg_opencs
IS
    passwordType constant number := 1;

	FUNCTION MD5 (passwd IN VARCHAR2) RETURN VARCHAR2 ;

	FUNCTION insertUser (
			usernameIn in VARCHAR2,
			emailIn in VARCHAR2 ) 
		RETURN NUMBER ;
	FUNCTION insertUser (
			usernameIn in VARCHAR2,
			emailIn in VARCHAR2,
	   	mod in number ) 
		RETURN NUMBER ;
	FUNCTION insertUser (
			usernameIn in VARCHAR2,
			emailIn in VARCHAR2,
		   	mannerIn in NUMBER,
			sexIn in VARCHAR2,
			birthIn in DATE,
		   	picIn in blob )
		RETURN NUMBER ;
	FUNCTION insertUser (
			usernameIn in VARCHAR2,
			emailIn in VARCHAR2,
			paswdIn in VARCHAR2 )
		RETURN NUMBER ;
	FUNCTION insertUser (
			usernameIn in VARCHAR2,
			emailIn in VARCHAR2,
		   	passwdIn in VARCHAR2,
			sexIn in VARCHAR2,
			birthIn in DATE,
		   	picIn in blob )
		RETURN NUMBER ;

END pg_opencs;
/


CREATE OR REPLACE PACKAGE BODY admin.pg_opencs
AS 
	
	----MD5加密
	FUNCTION MD5(passwd IN VARCHAR2)
	RETURN VARCHAR2
	IS
		retval VARCHAR2(32);
	BEGIN
		retval := utl_raw.cast_to_raw(DBMS_OBFUSCATION_TOOLKIT.MD5(INPUT_STRING => passwd)) ;
		RETURN retval;
	END;

	----添加用户
	FUNCTION insertUser (usernameIn IN VARCHAR2,emailIn in VARCHAR2)
	AS
	BEGIN
		INSERT INTO tb_user(username,email) values(usernameIn,emailIn);
		RETURN 1;
	END;

	----添加用户 带登陆验证模式简略添加
	FUNCTION insertUser (usernameIn in VARCHAR2,emailIn in VARCHAR2, mannerIn in number)
	AS 
	begin
		INSERT INTO tb_user(username, email, manner) values(usernameIn,emailIn, mannerIn);
	RETURN 1;
	END;

	----添加用户 带验证完整添加
	FUNCTION insertUser (usernameIn in VARCHAR2,
		emailIn in VARCHAR2,
	   	mannerIn in NUMBER,
		sexIn in VARCHAR2,
		birthIn in DATE,
	   	picIn in blob )
	AS
	BEGIN
		INSERT INTO tb_user(username,email,manner,sex,birth,pic) 
			values(usernameIn, emailIn, mannerIn, sexIn, birthIn, picIn);
	RETURN 1;
	END;

	----添加用户 本地验证模式简略添加
	FUNCTION insertUser (usernameIn in VARCHAR2,
		emailIn in VARCHAR2,
		passwdIn in VARCHAR2)
	AS 
	begin
		INSERT INTO tb_user(username, email, password) values(usernameIn,emailIn, mannerIn);
	RETURN 1;
	END;

	----添加用户 本地验证完整添加
	FUNCTION insertUser (usernameIn in VARCHAR2,
		emailIn in VARCHAR2,
	   	passwdIn in VARCHAR2,
		sexIn in VARCHAR2,
		birthIn in DATE,
	   	picIn in blob )
	AS
	BEGIN
		INSERT INTO tb_user(username,email, password,sex,birth,pic) 
			values(usernameIn, emailIn, passwdIn, sexIn, birthIn, picIn);
	RETURN 1;
	END;

END pg_opencs;
/
