import os
import socket

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

server_address = ('192.168.86.50', 10000)
print('starting up on {} port {}'.format(*server_address))
sock.bind(server_address)

while True:
	print('Waiting')
	data, address = sock.recvfrom(4096)
	print (address)
	os.startfile("Macros\\"+data.decode("utf-8")) 