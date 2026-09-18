import { useState } from 'react'
import type { CreateClipSegmentRequest } from './types'
import { Segments } from './clips/Segments'

type ClipEditorProps = {
  onUpload: (segments: CreateClipSegmentRequest[]) => void
}

export const ClipEditor = ({ onUpload }: ClipEditorProps) => {
  const [segments, setSegments] = useState<CreateClipSegmentRequest[]>([
  { startTime: 2, endTime: 3 },
  { startTime: 7, endTime: 8 },
])

  return (
    <>
      <Segments segments={segments} />

      <button
        type="button"
        onClick={() => {
          onUpload(segments)
          setSegments([])
        }}
      >
        Upload clips
      </button>
    </>
  )
}
