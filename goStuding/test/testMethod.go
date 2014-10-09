package main

import (
	"fmt"
)

type person struct {
	Name string
	Id   string
}

type student struct {
	person
	Age   int
	Grade int
}

func main() {
	li := &student{
		person: person{Name: "wcj", Id: "123456x"},
		Age:    17,
		Grade:  11,
	}
	fmt.Println(li)
	li.ReName("cjstudio")
	li.Agetho()
	li.ReId("66666")
	fmt.Println(li)
}

func (s *student) Agetho() {
	s.Age++
}

func (p *person) ReName(str string) {
	p.Name = str
}

func (p *person) ReId(str string) {
	p.Id = str
}
