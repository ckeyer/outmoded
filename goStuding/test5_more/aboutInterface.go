package main

import (
	"fmt"
)

type Human struct {
	name  string
	age   int
	phone string
}

type Student struct {
	Human
	school string
	loan   float32
}

type Employee struct {
	Human
	company string
	money   float32
}

func (h Human) Sing(lyrics string) {
	fmt.Println("Human:la,la,la....", lyrics)
}

func (h Human) SayHi() {
	fmt.Println("Hi,Human")
}

func (e Employee) SayHi() {
	fmt.Println("Hi,Employee")
}

func (s Student) Sing(lyrics string) {
	fmt.Println("Student:Go,GO,GO,GO", lyrics)
}

type Men interface {
	SayHi()
	Sing(lyrics string)
}

func main() {
	mike := Student{Human{"Mike", 13, "123123123"}, "Mit", 12.1}
	paul := Student{Human{"Paul", 14, "234432123"}, "Harvard", 99}
	sam := Employee{Human{"Sam", 43, "1223321111"}, "Golang Inc...", 12000}
	Tom := Employee{Human{"Sam", 43, "1223321111"}, "Things Ltd.", 122223}

	var i Men
	i = mike
	fmt.Println("This is Mike , a Student:")
	i.SayHi()
	i.Sing("Hero...")
	i = Tom
	fmt.Println("This is Tom, an Employee")
	i.SayHi()
	i.Sing("I am a big Hero")

	fmt.Println("Let's use a slice of Men and see what happens")
	x := make([]Men, 3)
	x[0], x[1], x[2] = paul, sam, mike
	for _, value := range x {
		value.SayHi()
		value.Sing("HeHeHe")
	}
}
