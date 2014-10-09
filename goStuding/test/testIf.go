package main

import (
	"fmt"
)

func main() {
	a := 0
	if a := 1; a > 2 {
		fmt.Println("a is bigger than 2", a)
	} else {
		fmt.Println("a is smaller than 2", a)
	}
	a++
	fmt.Println("the old a is:", a)
}
