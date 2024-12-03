![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)
![image](https://github.com/user-attachments/assets/7932d065-f401-461b-b10f-054ac3428bf2)


![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)

<a href="https://testerpresent.com.au/"><img src="https://img.shields.io/badge/Tester Present -Specialist Automotive Solutions-blue" /></a>

## Generic Diagnostic Tool
General purpose diagnostic software that allows you to control individual diagnostic services. Have not seen any open source generic diagnostic software for J2534 devices so I thought I would make some. Currently for use on vehicles with ECUs on a typical High Speed CAN and Medium Speed CAN, aiming for it to work with Ford, Mazda, JLR, Volvo and anything OBD2 compliant. Allows you to set the ECU RX & TX Address (ie 7E0, 7E8 for a Powertrain Control Module) and connect to that ECU, and perform basic diagnostic functions using both KWP2000 protocol or UDS protocol. Hoping to try and use this as reverse engineering software, it seems to be heading in that direction anyways. This is a work in progress... 

## Latest Update in Releases
![image](https://github.com/user-attachments/assets/e1370ac2-acb6-4277-8f2d-1d4652c536d1)

![image](https://github.com/user-attachments/assets/5a4d10e0-aa59-4a80-b0dc-51fae13e31ad)

![image](https://github.com/user-attachments/assets/15f95c3e-2c87-41c1-9b00-81e92119132e)



## Current Functionality (using KWP2000, UDS) implemented diagnostic services
- 0x10 Diagnostic Session Control
- 0x11 ECU Reset
- 0x3E Tester Present
- 0x27 Security Access & Bruteforcing tool
- 0x85 Control DTC Setting
- 0x22 DID bruteforcing, find all DIDs that return data
- 0x23 Direct Memory Read
- OBD2 Services
- CAN Sniffer
- VIN Decoder
- Store and Send Arbitrary PassThru messages to ECU

![image](https://github.com/user-attachments/assets/586e7fbf-9265-4dab-b46c-9ff85fc407cb)

    

![image](https://github.com/user-attachments/assets/c43cbd55-5c05-4653-8ea9-c111af294497)
![image](https://github.com/user-attachments/assets/d1ea71cb-21b5-47fb-aeef-4032bd605bdb)
![image](https://github.com/user-attachments/assets/ba8fb23b-3de2-4275-933c-e7bffbb3df7b)
![image](https://github.com/user-attachments/assets/1543b81b-6b83-4c1a-8391-e8cda4de3e17)





## Planned Functionality 

- Read and Clear Diagnostic Trouble Codes
- Enumerate all online ECUs
- PID Lookup tool via service 0x22


<img align="right" src="https://testerpresent.com.au/wp-content/uploads/2024/03/EDR@2x-1.png" height="20%" width="20%"/>

## J2534 Interface
This implementation currently only works with an OBDXPro FT J2534 interface(https://obdxpro.com). Hoping to troubleshoot it such that it is compliant with all J2534 interfaces, ie VCM2, VCM3, Tactrix Openport, Mongoose Pro. Feel free to fork and modify it to work with your devices.

## Executable Download
See the Releases Page.
![image](https://github.com/user-attachments/assets/5d286541-9565-4ab7-8677-83823695f371)
![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)
