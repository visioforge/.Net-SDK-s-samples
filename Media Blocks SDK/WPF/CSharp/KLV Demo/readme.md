# Media Blocks SDK .Net - KLV Demo (WPF)

This SDK sample demonstrates the integration and usage of the VisioForge Media Blocks SDK .Net within a WPF application to process video files. Specifically, it focuses on extracting KLV (Key-Length-Value) metadata from MPEG-TS (Transport Stream) files. The application initializes the media pipeline, sets up source blocks for file input, demultiplexes the MPEG-TS stream to extract metadata, and then directs the metadata to a KLV file sink block for output. Additionally, it includes UI elements for selecting input TS files and saving the extracted KLV data to a file, providing a practical example of handling media files and extracting metadata in a .NET environment.

## Features

- Demux and mux KLV data into MPEG-TS files

## Used blocks

- `BasicFileSourceBlock` - reads data from a file without decoding
- `MPEGTSDemuxBlock` - demultiplexes MPEG-TS streams
- `KLVFileSinkBlock` - writes KLV data to a file

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
