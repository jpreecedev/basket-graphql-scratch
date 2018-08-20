import * as React from 'react'
import axios from 'axios'
import styles from './styles.module.scss'

class App extends React.Component {
  state = {
    humans: []
  }

  requestData = () => {
    axios(
      config,
      data: JSON.stringify({
        query: `{
      humans {
        name
      }
    }`
      })
    }).then(resp => {
      this.setState({
        humans: resp.data
      })
    })
  }

  render() {
    return (
      <header>
        <h1 className={styles.module}>GraphQL with .NET Back end Proof-of-Concept</h1>
        <div className={styles.container}>
          <button onClick={this.requestData}>Request some data</button>
          <p className={styles.result}>{JSON.stringify(this.state.humans)}</p>
        </div>
      </header>
    )
  }
}

export default App
