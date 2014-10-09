package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"regexp"
)

const (
	TEmail       = `^([\w\.\_]{2,10})@(\w{1,}).([a-z]{2,4})$`
	TId          = `^(\d{17})([0-9]|X)$`
	TChineseName = "^[\\x{4e00}-\\x{9fa5}]+$"
	TEnglishName = "^[a-zA-Z]+$"
	TMobile      = `^(1[3|4|5|8][0-9]\d{4,8})$`
)

func main() {
	running := true
	reader := bufio.NewReader(os.Stdin)
	for running {
		fmt.Print("Input the type of validation:")
		data, _, _ := reader.ReadLine()
		command := string(data)
		switch command {
		case "exit":
			running = false
			log.Println("Exiting...")
		case "email":
			fmt.Printf("Input your %s:", command)
			v, _, _ := reader.ReadLine()

			if m, _ := regexp.MatchString(TEmail, string(v)); !m {
				fmt.Println(string(v) + " is not an emailaddress")
			} else {
				fmt.Println("yes")
			}
		case "name":
			fmt.Printf("Input your %s:", command)
			v, _, _ := reader.ReadLine()

			if m, _ := regexp.MatchString(TChineseName, string(v)); m {
				fmt.Println(string(v) + " is a Chinese name")
			} else if m, _ := regexp.MatchString(TEnglishName, string(v)); m {
				fmt.Println(string(v) + " is a English name")
			} else {
				fmt.Println(string(v) + " is not a name")
			}
		case "ID":
			fmt.Printf("Input your %s:", command)
			v, _, _ := reader.ReadLine()

			if m, _ := regexp.MatchString(TId, string(v)); !m {
				fmt.Println(string(v) + " is not an ID")
			} else {
				fmt.Println("yes")
			}
		case "mobile":
			fmt.Printf("Input your %s:", command)
			v, _, _ := reader.ReadLine()

			if m, _ := regexp.MatchString(TMobile, string(v)); !m {
				fmt.Println(string(v) + " is not a mobile number")
			} else {
				fmt.Println("yes")
			}
		default:
			fmt.Println("The type of validation should be in \" email,name,ID,mobile,exit \"")
			continue
		}
	}
}
