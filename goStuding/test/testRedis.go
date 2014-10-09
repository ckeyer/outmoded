package main

import (
	"fmt"
	"github.com/hoisie/redis"
	"strconv"
)

var rediscli redis.Client

func main() {
	rediscli = redis.Client{
		Addr:        "127.0.0.1:6379",
		Db:          0, // default db is 0
		Password:    "pink",
		MaxPoolSize: 10000,
	}
	if err := rediscli.Auth("pink"); err != nil {
		fmt.Println("Auth: ", err.Error())
		return
	}
	viewerCount := GetWebsiteViewerCount(rediscli)
	fmt.Println(viewerCount)
}

func GetWebsiteViewerCount(client redis.Client) (n int) {
	v, err := client.Get("ViewerCount")
	if err == nil {
		n, _ = strconv.Atoi(string(v))
		n++
		client.Set("ViewerCount", []byte(strconv.Itoa(n)))
	} else {
		client.Set("ViewerCount", []byte("100"))
		n = 100
	}
	return
}
