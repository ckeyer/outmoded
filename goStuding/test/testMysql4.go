package main

import (
	"database/sql"
	"fmt"
	_ "mysql"
	//"time"
)

func main() {
	db, err := sql.Open("mysql", "stu:manager@/test?charset=utf8")
	checkErr(err)
	// 插入数据
	// stmt, err := db.Prepare("INSERT userinfo SET username=?,departname=?,created=?")
	// checkErr(err)
	// res, err := stmt.Exec("astaxie", " 研发部门", "2012-12-09")
	// checkErr(err)
	// id, err := res.LastInsertId()
	// checkErr(err)
	// fmt.Println(id)
	// 更新数据
	// stmt, err := db.Prepare("update tStudents set sex=? where name=?")
	// //120checkErr(err)
	// res, err := stmt.Exec(1, "hj")
	// checkErr(err)
	// affect, err := res.RowsAffected()
	// checkErr(err)
	// fmt.Println(affect)
	// 查询数据
	rows, err := db.Query("SELECT * FROM tStudents")
	checkErr(err)
	for rows.Next() {
		var Id int
		var name string
		var sex int
		err = rows.Scan(&Id, &name, &sex)
		checkErr(err)
		fmt.Print(Id, " ")
		fmt.Print(name, " ")
		fmt.Println(sex)
	}
	// 删除数据
	// stmt, err = db.Prepare("delete from userinfo where uid=?")
	// checkErr(err)
	// res, err = stmt.Exec(id)
	// checkErr(err)
	// affect, err = res.RowsAffected()
	// checkErr(err)
	// fmt.Println(affect)
	db.Close()
}
func checkErr(err error) {
	if err != nil {
		panic(err)
	}
}
