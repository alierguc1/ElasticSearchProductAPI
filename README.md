
<p align="center">
  <img width="600" height="200" src="https://github.com/alierguc1/ElasticSearchProductAPI/blob/master/raw/Elasticsearch_logo.svg.png?raw=true">
</p>

<p align="center">
  <img width="200" height="200" src="https://github.com/alierguc1/ElasticSearchProductAPI/blob/master/raw/nest.png?raw=true">
</p>


#### REQUEST

##### Get All Products
```http
  GET http://localhost:5074/api/Products/GetAllProducts
```

##### Create Product
```http
  POST http://localhost:5074/api/Products/CreateProduct
```
| Body | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `name` | `string` | **Gerekli**. name. |
| `stockCode` | `string` | **Gerekli**. stockCode. |
| `price` | `int` | **Gerekli**. price. |
| `stock` | `int` | **Gerekli**. stock. |
| `warrantyPeriod` | `int` | **Gerekli**. warrantyPeriod. |
| `width` | `int` | **Gerekli**. width. |
| `height` | `int` | **Gerekli**. height. |
| `color` | `int` | **Gerekli**. color. |

##### Get Product By Id
```http
  GET http://localhost:5074/api/Products/GetProductById/{productId}
```

| Body | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `productId` | `string` | **Gerekli**. productId. |

##### Product Delete
```http
  DELETE http://localhost:5074/api/Products/DeleteProduct/{productId}
```

| Body | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `productId` | `string` | **Gerekli**. productId. |

##### Update Product
```http
  PUT http://localhost:5074/api/Products/UpdateProduct
```
| Body | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `Id` | `string` | **Gerekli**. Id. |
| `name` | `string` | **Gerekli**. name. |
| `stockCode` | `string` | **Gerekli**. stockCode. |
| `price` | `int` | **Gerekli**. price. |
| `stock` | `int` | **Gerekli**. stock. |
| `warrantyPeriod` | `int` | **Gerekli**. warrantyPeriod. |
| `width` | `int` | **Gerekli**. width. |
| `height` | `int` | **Gerekli**. height. |
| `color` | `int` | **Gerekli**. color. |

<hr/>

#### DOCKER COMPOSE

```sh
version: "3"

services: 
  elasticsearch:
    image: docker.elastic.co/elasticsearch/elasticsearch:8.7.1
    ports:
      - "9200:9200"
    environment: 
      - discovery.type=single-node
      - xpack.security.enabled=false
    networks: 
      - logging-network

  logstash:
    image: docker.elastic.co/logstash/logstash-oss:6.2.2
    ports:
      - "5000:5000"
    environment:
      LS_JAVA_OPTS: "-Xmx256m -Xms256m"
    networks:
      - logging-network
    depends_on:
      - elasticsearch
    links:
      - elasticsearch

  kibana:
    image: docker.elastic.co/kibana/kibana:8.7.1
    depends_on:
      - logstash
    ports: 
      - 5601:5601
    networks: 
      - logging-network

  httpd:
    image: httpd:latest
    depends_on:
      - logstash
    ports:
      - 80:80
    logging:
      driver: gelf
      options:
        # Use udp://host.docker.internal:12201 when you are using Docker Desktop for Mac
        # docs: https://docs.docker.com/docker-for-mac/networking/#i-want-to-connect-from-a-container-to-a-service-on-the-host
        # issue: https://github.com/lvthillo/docker-elk/issues/1
        gelf-address: "udp://localhost:12201"

networks: 
  logging-network:
    driver: bridge
```
