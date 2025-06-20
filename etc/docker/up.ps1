docker network create tmsms --label=tmsms
docker-compose -f composes/elasticsearch.yml up -d
docker-compose -f composes/grafana.yml up -d
docker-compose -f composes/kibana.yml up -d
docker-compose -f composes/prometheus.yml up -d
docker-compose -f composes/rabbitmq.yml up -d
docker-compose -f composes/redis.yml up -d
docker-compose -f composes/sqldata.yml up -d
exit $LASTEXITCODE