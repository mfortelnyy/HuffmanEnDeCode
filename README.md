Huffman Encoding & Decoding Application
A Windows Forms application for encoding and decoding text files using Huffman Coding, a lossless data compression algorithm.

📌 Overview
This project implements Huffman Coding, an optimal prefix coding algorithm used for data compression. The application provides an interactive graphical interface to encode text into a compressed format and decode it back to its original form.

The application is built using C# (.NET Windows Forms) and follows object-oriented programming principles to construct the Huffman Tree efficiently. It includes functionalities for users to upload text files, generate frequency-based Huffman trees, and visualize the encoding and decoding processes.

🚀 Features
✔ Encode Text Files: Compress input text using Huffman Coding and generate binary representations.
✔ Decode Encoded Files: Convert compressed Huffman-encoded text back to its original form.
✔ Dynamic Huffman Tree Generation: Automatically constructs the Huffman Tree based on character frequency.
✔ User-Friendly GUI: Developed using Windows Forms for a smooth, interactive experience.
✔ File Upload & Processing: Users can browse and upload text files for encoding or decoding.
✔ Character Frequency Analysis: Displays the frequency table and binary codes assigned to each character.
✔ Binary Encoding Table: Visualizes the encoding process and how characters are mapped to binary codes.

🛠️ Technologies Used
C# (.NET Framework)
Windows Forms (WinForms)
Object-Oriented Programming (OOP)
Data Structures (Binary Trees, Priority Queues)
File Handling (OpenFileDialog, Text Processing)
📂 Project Structure
Program.cs – Entry point for the application.
Node.cs – Defines the Huffman Tree Node structure.
HuffmanTree.cs – Core logic for building the Huffman Tree, sorting, encoding, and decoding.
Form1.cs – Main UI Form with buttons for encoding and decoding.
Form2.cs - Form5.cs – Additional UI Forms for file selection, tree visualization, and result display.
🖥️ How to Run
Clone the repository
sh
Copy
Edit
git clone https://github.com/yourusername/HuffmanEnDeCode.git
cd HuffmanEnDeCode
Open the project in Visual Studio
Build and Run the application (Ctrl + F5)
📷 Screenshots
(Add screenshots of the application UI, Huffman tree visualization, and encoding results.)