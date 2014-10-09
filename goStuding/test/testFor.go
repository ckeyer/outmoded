package main

import (
	"fmt"
)

func main() {
	var s int = 0
	for i := 0; i <= 100; i++ {
		s += i
	}
	fmt.Println("1+2+3+...+100=", s)

loo1:
	for {
		for i := 0; i < 10; i++ {
			if i > 3 {
				break loo1
			}
			fmt.Printf("%d  ", i)
		}
	}
	fmt.Println(" ")

loo2:
	for i := 0; i < 10; i++ {
		for {
			fmt.Printf("%d  ", i)
			continue loo2
		}
	}
}
