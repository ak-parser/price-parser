# Introduction

Web API for LynkCo UI client

# Build and Run

1. Open Lynkco.Warranty.WebAPI directory in a terminal
2. Run: "docker build -t lynkco-web-api -f Lynkco.Warranty.WebAPI.Host/Dockerfile ."
3. Run: "docker run -it --rm -p 5000:80 --name lynkco-web-api-inst lynkco-web-api"
4. Open URL http://localhost:5000/swagger/index.html
