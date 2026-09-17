import './App.css'
import { AuthGuard } from './features/auth/components/AuthGuard/AuthGuard'
import { LoginView } from './features/auth/components/LoginView'
import { UserView } from './features/auth/controllers/UserView'
import { VideoPage } from './features/videos/videoPage/VideoPage'
import styles from './styles.module.scss';

function App() {
  return (
    <AuthGuard fallback={<LoginView />}>
      <div className={styles.authenticatedRoot}>
        <UserView />
        <section className={styles.appContainer}>
          <div className={styles.authenticatedLayout}>
            <VideoPage />
          </div>
        </section>
      </div>
    </AuthGuard>
  )
}

export default App
