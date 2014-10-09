package main

import (
	"bufio"
	"fmt"
	"log"
	"net/http"
	"os"
)

var urlpath string = "testUrl.txt"

func main() {
	urls := GetUrls(urlpath)
	f, _ := os.Create("hbny.txt")
	for i, v := range urls {
		fmt.Printf("%d:%s-----%n\n", i, v, len(v))
		//str := GetHtmlString(v)
		//fmt.Println(str)
		// fmt.Printf("%s", GetHtmlString("http://172.16.2.21"))
		f.Write(GetHtmlBytes(v))
	}
	f.Close()
}

func CheckErr(err error) {
	if err != nil {
		log.Println(err)
	}
}

func GetUrls(path string) (urls []string) {
	f, err := os.Open(path)
	if err != nil {
		fmt.Printf("fuck %v\n", err)
		os.Exit(1)
	}
	defer f.Close()

	br := bufio.NewReader(f)
	for {
		line, err := br.ReadString('\n')
		if err != nil {
			break
		} else {
			urls = append(urls, line[:len(line)-1])
		}
	}
	return
}

func GetHtmlBytes(url string) []byte {
	resp, err := http.Get(url)
	html := make([]byte, 0)
	buf := make([]byte, 1024)

	if err != nil {
		CheckErr(err)
		return html
	}
	if resp.StatusCode == http.StatusOK {
		fmt.Println(resp.StatusCode)
	}
	defer resp.Body.Close()

	for {
		n, _ := resp.Body.Read(buf)
		if 0 == n {
			break
		}
		html = append(html, buf[:]...)
	}
	return html
}
func GetHtmlString(url string) (html string) {
	resp, err := http.Get(url)
	if err != nil {
		CheckErr(err)
		return
	}
	if resp.StatusCode == http.StatusOK {
		fmt.Println(resp.StatusCode)
	}
	defer resp.Body.Close()

	buf := make([]byte, 1024)

	for {
		n, _ := resp.Body.Read(buf)
		if 0 == n {
			break
		}
		html = fmt.Sprintf("%s%s", html, buf)
	}
	return
}
