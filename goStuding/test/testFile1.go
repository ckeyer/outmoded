package main

import (
	"fmt"
	"os"
	"strconv"
	//"io"
)

func main() {
	userDir := "dir"
	userFile := "test.txt"
	err := os.Chdir(userDir)
	if err != nil {
		fmt.Println(err)
		err := os.Mkdir(userDir, os.ModeDir)
		if err != nil {
			fmt.Println(err)
			return
		}
	}
	fout, err := os.Open(userFile)
	if err != nil {

		fout, err := os.Create(userFile)
		defer fout.Close()
		if err != nil {
			fmt.Println("error ", err)
		}
		for i := 0; i < 10; i++ {
			fout.WriteString(strconv.Itoa(i) + ":Just a test!\r\n")
			fout.Write([]byte("Just a test!\r\n"))
		}
	} else {
		b := make([]byte, 8)
		for {
			sb := make([]byte, 1)
			n, _ := fout.Read(sb)
			b = append(b, sb[0])
			if 0 == n {
				break
			}
			//fmt.Println(strconv.Itoa(n) + string(b[:n]))
		}
		fmt.Printf("%s\r\n", b)
		fout.Close()
	}
}
