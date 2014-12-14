package opencs

import (
	"github.com/hoisie/redis"
	"strconv"
)

const (
	ViewerCountKey = "ViewerCount"
	UrlToDeny = "http://www.baidu.com"
)

type Website struct {
	ViewerCount string
	rediscli    redis.Client
}

func (w *Website) Init_Website() (err error) {
	w.rediscli = redis.Client{
		Addr:        "127.0.0.1:6379",
		Db:          0, // default db is 0
		// Password:    "pink",
		MaxPoolSize: 10000,
	}
	// if err = w.rediscli.Auth("pink"); err != nil {
	// 	return
	// }
	w.GetWebsiteViewerCount()
	return
}

func (w *Website) GetWebsiteViewerCount() {
	v, err := w.rediscli.Get("ViewerCount")
	if err == nil {
		n, _ := strconv.Atoi(string(v))
		n++
		w.rediscli.Set("ViewerCount", []byte(strconv.Itoa(n)))
		} else {
			w.rediscli.Set("ViewerCount", []byte("100"))
			v = []byte("100")
		}
		w.ViewerCount = string(v)
		return
}


func (w *Website) AddToDenyList(Ip string) {
	w.rediscli.Set(Ip,[]byte("d"))
	w.rediscli.Expire(Ip,20)
}

func (w *Website) ExistsDenyList(Ip string) bool {
	v, err := w.rediscli.Exists(Ip)
	if err == nil {
		return v
	}
	return false
}
