import axios  from 'axios'

const api = axios.create ({
    baseURL :'https://localhost:7015/api',
})

export default api;