import { LoginButton } from '../controllers/LoginButton'
import styles from '../../../styles.module.scss'

export const LoginView = () => {
  return (
    <main className={styles.loginView}>
      <h1>Get started</h1>
      <LoginButton />
    </main>
  )
}
