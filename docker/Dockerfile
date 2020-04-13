FROM mysql:8.0

COPY --chown=1000:1000 ./config.sh /home/mysql/config.sh

RUN chmod +x /home/mysql/config.sh;

#ENTRYPOINT [ "/home/mysql/config.sh" ]

CMD ["mysqld"]