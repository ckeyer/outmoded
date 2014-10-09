package main

import (
	"fmt"
)

type person struct {
	Name string
	Id   string
	Age  int
}
type teacher struct {
	person
	class string
}

func main() {
	a := person{}
	a.Age = 19
	a.Name = "wcj"
	a.Id = "123456x"
	fmt.Println(a)
	b := person{"dyc", "654321", 22}
	fmt.Println(b.Name, b.Id, b.Age)
	c := person{
		Name: "ljx",
		Id:   "135246x",
		Age:  23,
	}
	fmt.Println(c)

	fmt.Println("匿名结构：")
	d := struct {
		Name string
		Age  int
	}{
		Name: "lm",
		Age:  18,
	}
	fmt.Println(d)

	fmt.Println("Test 3:")
	e := teacher{class: "english", person: person{Name: "ysl", Id: "3154321", Age: 17}}
	fmt.Println(e)
	e.Name = "doudou"
	e.class = "network"
	fmt.Println(e)
}
