import type { VideoClipsProps } from './types'
import styles from './styles.module.scss'

export const VideoClips = ({ clips }: VideoClipsProps) => {
  return (
    <section className={styles.container} aria-label="Video clips">
      <h2>Clips</h2>

      <ul className={styles.list}>
        {clips.map((clip, index) => (
          <li className={styles.clip} key={`${clip.start}-${clip.end}-${index}`}>
            <span>Clip {index + 1}</span>
            <span>
              {clip.start}s - {clip.end}s
            </span>
          </li>
        ))}
      </ul>
    </section>
  )
}
