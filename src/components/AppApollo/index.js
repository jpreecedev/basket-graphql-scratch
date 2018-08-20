import * as React from 'react'
import gql from 'graphql-tag'
import { Query, withApollo } from 'react-apollo'

import styles from './styles.module.scss'

class App extends React.Component {
  state = {
    humans: []
  }

  foo = () => {
    return this.props.client
      .query({
        query: gql`
          query {
            humans {
              name
            }
          }
        `
      })
      .then(({ data }) => {
        this.setState({ humans: data.humans })
      })
  }

  render() {
    return (
      <header>
        <h1 className={styles.module}>GraphQL with .NET Back end Proof-of-Concept</h1>
        <div className={styles.container}>
          <button onClick={this.foo}>Request some data</button>
        </div>
        <p className={styles.result}>{JSON.stringify(this.state.humans)}</p>
      </header>
    )
  }
}

export default withApollo(App)
