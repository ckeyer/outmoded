package main

import (
	"fmt"
)

func main() {
	fmt.Println(Add(1, 3))
	fmt.Println(Adds(1, 2, 3, 4, 5))

	fmt.Println("Test 2:")
	a := func(a ...int) (c int) {
		c = 0
		for _, v := range a {
			c += v
		}
		return
	}
	fmt.Println(a(1, 2, 3))

	fmt.Println("Test 2:")
	b := closure(1)
	fmt.Println(b(2))
	fmt.Println(b(5))

	fmt.Println("Test 3:")
	c := func() {
		fmt.Println("c")
		fmt.Println("d")
	}
	defer fmt.Printf("a\n")
	defer fmt.Printf("b\n")
	defer c()
	defer func() {
		fmt.Println("e")
		fmt.Println("f")
	}()
}

func Add(a, b int) (c int) {
	c = a + b
	return
}

func Adds(a ...int) (c int) {
	c = 0
	for _, v := range a {
		c += v
	}
	return
}

func closure(x int) func(int) int {
	return func(y int) int {
		fmt.Printf("x: %p\n", &x)
		fmt.Printf("y: %p\n", &y)
		return x + y
	}
}
