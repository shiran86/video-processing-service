import './App.css'
import { AuthStatus } from './features/auth/controllers/AuthStatus'
import { LoginButton } from './features/auth/controllers/LoginButton'

function App() {

  return (
    <>
      <section id="center">

        <div>
          <h1>Get started</h1>
          <LoginButton />
        </div>

        <AuthStatus />
      </section>

    </>
  )
}

export default App
