<a href="https://testerpresent.com.au/">
<img width="1326" height="201" alt="image" src="https://github.com/user-attachments/assets/d6519415-9430-4fa9-aedf-41249296c096" />
</a>


<a href="https://testerpresent.com.au/"><img src="https://img.shields.io/badge/Tester Present Specialist Automotive Solutions -Open Source Projects- blue" /></a>


![image](https://github.com/user-attachments/assets/7932d065-f401-461b-b10f-054ac3428bf2)



![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)


## Generic Diagnostic Tool
Generic Diagnostic Tool is an open source, free J2534 PassThru software tool for general purpose use of raw diagnostic protocols on an ECU. It can be used for diagnostics, reverse engineering, development and hacking of ECUs.

This is general purpose diagnostic software that allows you to control individual diagnostic services. Have not seen any open source generic diagnostic software for J2534 devices so I thought I would make some. Currently for use on vehicles with ECUs on a typical High Speed CAN and Medium Speed CAN, aiming for it to work with Ford, Mazda, JLR, Volvo and anything OBD2 compliant. Allows you to set the ECU RX & TX Address (ie 7E0, 7E8 for a Powertrain Control Module) and connect to that ECU, and perform basic diagnostic functions using both KWP2000 protocol or UDS protocol. This is a work in progress... 

## Latest Update Announcements
<details >
<summary>Update 13/02/2025</summary>
<br>
Have uploaded the current code base as it is, and released the latest version in the releases tab. Still lots of bugs around the place, and many features yet to be implemented, but progress is progress!
</details>

<details >
<summary>Update 04/12/2024</summary>
<br>
Scaling and Resolution issue has been fixed. Added more to Security Access & DMR Tabs, CAN Sniffer should be working now, VIN grabber and decoder should be working, OBD2 should be working. Tested with an OBDXPro FT and a Ford VCM2, other interfaces should work now as well, this has come at the cost of having MidSpeed CAN access for the time being.   
</details>
<details>
<summary>Update 08/12/2024</summary>  
<br>
Diagnostic Fault Codes can now be read out in their own tab, codes can be read and cleared. No Definitions as of yet.  
</details>
<details>
<summary>Update 11/12/2024</summary>
<br>
Added another 400 secret keys to the bruteforcer, taken from JLR SDD and thanks to https://github.com/smartgauges/exml so now the Bruteforcer will be able to unlock JLR ECUs up until 2016. Also adeed PSA Security Access Algo.
</details>

<details>
<summary>Update 13/12/2024</summary>
<br>
Started work on a nicely formatted DTC table to replace the single listBox currently being used to display DTC, as well as fully parsing out each fault code to display the type, sub type and definition of each DTC in the table. Collected various definitions and dictionaries with a view to creating a mega DTC definition dictionary that can cover all bases.  
</details>
  
<details>
<summary>Update 24/12/2024</summary>
<br>
Started the code to use 29 BIT CAN Identifiers for the ECU RX and TX Address.  
</details>
  
![image](https://github.com/user-attachments/assets/f25639d4-8942-4e41-bc26-7130dd33a0fb)

![image](https://github.com/user-attachments/assets/375d5be0-9f75-4e11-b00e-bbe185f020af)

![image](https://github.com/user-attachments/assets/6de3e637-a58b-4a6d-ad4c-553c123e2361)





## Needed for the project
Things such as security access algorithms and seed keys from various OEMs, Diagnostic Fault Code definitions, protocol specification sheets, ECU information, DID/PID definitions and anything else that is related are needed to expand the project. If you are able to supply any of these things it would be greatly appreciated. ACTIVELY LOOKING FOR DIAGNOSTIC TROUBLE CODE DEFINTIIONS & DICTIONARIES. Feel free to get in touch!


## Current Functionality (using KWP2000, UDS) implemented diagnostic services
- 0x10 Diagnostic Session Control
- 0x11 ECU Reset
- 0x14 Clear Diagnostic Information (Clear DTC)
- 0x18 Read Diagnostic Information (Read DTC), DTC has its own tab now with a read out of read fault codes printed into a list box
- 0x3E Tester Present
- 0x27 Security Access & Bruteforcing tool
- 0x85 Control DTC Setting
- 0x22 DID/PID bruteforcing, find all DID/PID that return data
- 0x23 Direct Memory Read, for reading out flash memory/EEPROM
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

- Read and Clear Diagnostic Trouble Codes (partially conpleted)
- Enumerate all online ECUs(ECU RX and TX CAN ID identifier)
- Flash Toolkit
- Diagnostic Command (service 0xB1)
- Routine Control (service 0x31)
- Wtite Data to ECU
- Communication Control (service 0x28)
- ECU Self Tests
- Request Download/Upload and Transfer Data (services 0x34, 0x35 and 0x36)
- Expand to cover 29 Bit CAN IDs as ECU addresses

## 64 Bit Mode
The software can be run as x64, if you are using the OBDxPro FT J2534 Interface, as this has x64 drivers available to use, where as no other J2534 device manufacturers have implemented a 64 bit J2534 Driver. This is needed for bruteforcing security access to prevent an out of memory exception. A 64 Bit Version of the software will be available in the releases pages shortly.

<img align="right" src="https://testerpresent.com.au/wp-content/uploads/2024/03/EDR@2x-1.png" height="20%" width="20%"/>

## J2534 Interface
This implementation currently only works with an OBDXPro FT J2534 interface(https://obdxpro.com). Hoping to troubleshoot it such that it is compliant with all J2534 interfaces, ie VCM2, VCM3, Tactrix Openport, Mongoose Pro. Feel free to fork and modify it to work with your devices.

<details>
<summary>Update 07/12/2024</summary>
<br>
Minor modifications to the J2534 code have proven successful and I have tested the software with a Ford VCM2, Tactrix Openport and Mongoose Pro successfully. Still have to look into using PassThruIoctl for connecting to MidSpeed CANbuses. Looking for more interfaces to be tested.  
</details>

## Technical Support
If you are using this software and require techncial support, Tester Present Specialist Automotive solutions provides technical support for $150 AUD per hour. Feel free to get in touch if you require support. https://testerpresent.com.au

## Executable Download
See the Releases Page.

## Contact Details

![TesterPresentNewBusinessCard](https://github.com/user-attachments/assets/e02fb18b-9eef-4764-a2be-81e060dc8bb3)
![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)
