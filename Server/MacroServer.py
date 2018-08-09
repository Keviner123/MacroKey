import pyautogui
import os
import socket
from flask import Flask
app = Flask(__name__, static_folder='Images')
 
@app.route('/page/<string:PageID>')
def GetPage(PageID):
	f = open("Pages\\"+PageID,"r")
	contents = f.read()
	f.close()
	return(contents)

if __name__ == "__main__":
	app.run("192.168.1.33", port=5000, threaded=True)

