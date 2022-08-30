package main

import (
	"fmt"
	"log"
	"net"
	"net/http"
)

const (
	ServerHost = "localhost"
	ServerPort = "28080"
)

func greeting(w http.ResponseWriter, _ *http.Request) {
	fmt.Fprintf(w, "Hello")
}

func login(w http.ResponseWriter, _ *http.Request) {
	fmt.Fprintf(w, "Login")
}
func logout(w http.ResponseWriter, _ *http.Request) {
	fmt.Fprintf(w, "Logout")
}

func main() {
	fullAddr := net.JoinHostPort(ServerHost, fmt.Sprint(ServerPort))

	http.HandleFunc("/", greeting)
	http.HandleFunc("/login", login)

	http.HandleFunc("/logout", logout)
	err := http.ListenAndServe(fullAddr, nil)
	if err != nil {
		log.Fatal("error starting http server : ", err)

		return
	}
}
