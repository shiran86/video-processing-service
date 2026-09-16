import type { VideoPlayerProps } from './types'

export const VideoPlayer = ({ controls = true, ...props }: VideoPlayerProps) => {
  return <video controls={controls} {...props} />
}
