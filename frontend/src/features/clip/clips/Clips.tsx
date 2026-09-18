import type { ClipsProps } from './types'
import styles from './styles.module.scss'

export const Clips = ({ clips, onUpload }: ClipsProps) => {
  return (
    <section className={styles.container} aria-label="Video clips">
      <h2>Clips</h2>

      <ul className={styles.list}>
        {clips.map((clip, index) => (
          <li className={styles.clip} key={`${clip.startTime}-${clip.endTime}-${index}`}>
            <span>Clip {index + 1}</span>
            <span>
              {clip.startTime}s - {clip.endTime}s
            </span>
          </li>
        ))}
      </ul>

      <button type="button" onClick={() => onUpload(clips)}>
        Upload clips
      </button>
    </section>
  )
}
