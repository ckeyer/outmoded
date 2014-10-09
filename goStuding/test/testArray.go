package main

import (
	"fmt"
)

func main() {
	arr1 := [...]int{1, 2, 2: 3, 5: 6}
	// fmt.Println("arr1 has ", len(arr1))
	fmt.Println(arr1)
	var arr2 [10]byte
	for i := 0; i < 10; i++ {
		arr2[i] = byte(i + 97)
	}
	s1 := arr2[:5]
	s2 := arr2[5:]
	s3 := arr2[3:8]
	s4 := s3[2:4]
	fmt.Println(string(arr2[:]), string(s1), string(s2), string(s3), string(s4))
	s4[0] = '@'
	s4[1] = '$'
	fmt.Println(string(arr2[:]), string(s1), string(s2), string(s3), string(s4))
	// s1 = append(s1, '1', '2', '3')
	// fmt.Println(string(arr2[:]), string(s1), string(s2), string(s3), string(s4))
	s1 = append(s1, '4', '5', '6', '7', '8', '9')
	fmt.Println(string(arr2[:]), string(s1), string(s2), string(s3), string(s4))
	fmt.Println("Test 2:")
	sa := make([]int, 3, 6)
	fmt.Printf("%v %p\n", sa, sa)
	sa = append(sa, 1, 2, 3)
	fmt.Printf("%v %p\n", sa, sa)
	sa = append(sa, 4, 5, 6)
	fmt.Printf("%v %p\n", sa, sa)

}
