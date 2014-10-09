package main

import (
	"database/sql"
	"encoding/xml"
	"fmt"
	// "io/ioutil"
	//_ "mysql"
)

const (
	Header = `<?xml version="1.0" encoding="UTF-8"?>` + "\n"
)

type TdataItems struct {
	Id        int
	DataItem  string
	ItemCode  string
	Unit      string
	Max_Value float32
	Min_Value float32
}

type Result struct {
	XMLName xml.Name `xml:"persons"`
	Persons []Person `xml:"person"`
}
type Person struct {
	Name      string   `xml:"name,attr"`
	Age       int      `xml:"age,attr"`
	Career    string   `xml:"career"`
	Interests []string `xml:"interests>interest"`
}

func main() {
	db, err := sql.Open("mysql", "stu:manager@/dbo?charset=utf8")
	checkErr(err)

	rows, err := db.Query("SELECT * FROM TDataItem")
	checkErr(err)
	for rows.Next() {
		var tb1 TdataItems
		err = rows.Scan(&tb1.Id, &tb1.DataItem, &tb1.ItemCode, &tb1.Unit, &tb1.Max_Value, &tb1.Min_Value)
		checkErr(err)
		fmt.Println(tb1)
	}
	// var result Result

	checkErr(err)

}

func checkErr(err error) {
	if err != nil {
		panic(err)
	}
}
