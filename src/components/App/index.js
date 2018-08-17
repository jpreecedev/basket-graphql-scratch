import * as React from 'react'
import styles from './styles.module.scss'

const App = () => (
  <header>
    <h1 className={styles.module}>GraphQL with .NET Back end Proof-of-Concept</h1>
    <div className={styles.container}>
      <button>Request some data</button>
      <p className={styles.result}>There is nothing to display.</p>
    </div>
  </header>
)

export default App
