#!/bin/sh
echo "Adding permissions to root user..."
mysql -u ${MYSQL_USER} -p${MYSQL_ROOT_PASSWORD} -e "GRANT ALL PRIVILEGES ON ${MYSQL_DATABASE}.* TO '${MYSQL_USER}'@'%';"
mysql -u ${MYSQL_USER} -p${MYSQL_ROOT_PASSWORD} -e "FLUSH PRIVILEGES;"
mysql -u ${MYSQL_USER} -P${MYSQL_ROOT_PASSWORD} -e "SET GLOBAL sql_mode=(SELECT REPLACE(@@sql_mode,'ONLY_FULL_GROUP_BY',''));"
echo "permissions added to root user"
