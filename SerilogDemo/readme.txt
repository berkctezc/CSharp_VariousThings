
# Seq docker command
docker run -d --restart unless-stopped --name seq -e ACCEPT_EULA=Y -v <LogDirectory>:/data -p 8081:80 datalust/seq:latest