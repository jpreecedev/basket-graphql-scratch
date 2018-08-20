import * as React from 'react'
import * as ReactDOM from 'react-dom'
import 'regenerator-runtime/runtime'

import { ApolloProvider } from 'react-apollo'
import { ApolloClient } from 'apollo-client'
import { HttpLink } from 'apollo-link-http'
import { InMemoryCache } from 'apollo-cache-inmemory'

import App from './components/AppApollo'
import '../global/styles'

const client = new ApolloClient({
  link: new HttpLink({
    uri: 'http://localhost:50060/api/graphql'
  }),
  cache: new InMemoryCache()
})

ReactDOM.render(
  <ApolloProvider client={client}>
    <App />
  </ApolloProvider>,
  document.getElementById('root')
)
