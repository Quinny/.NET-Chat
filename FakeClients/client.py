import websocket
import thread
import time
import sys
import random

MESSAGE = open("message.txt").read()

def on_message(ws, message):
    print message

def on_error(ws, error):
    print error

def on_close(ws):
    print "[-] Lost connection"

def on_open(ws):
    def run(*args):
        ws.send("//registerName:dude")
        while(True):
            time.sleep(random.randint(1, 3))
            ws.send(MESSAGE)
        ws.close()
        print "[-] Thread died"
    thread.start_new_thread(run, ())

if __name__ == "__main__":
    for i in range(int(sys.argv[1])):
        websocket.enableTrace(True)
        ws = websocket.WebSocketApp("ws://localhost:8181",
                on_message = on_message,
                on_error = on_error,
                on_close = on_close)

        ws.on_open = on_open
        thread.start_new_thread(ws.run_forever, ())
    raw_input()
