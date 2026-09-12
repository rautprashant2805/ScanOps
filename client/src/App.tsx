import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react"

function App() {

  const [equipments, setEquipments] = useState<Equipment[]>([]);

  useEffect(() => {
    axios.get<Equipment[]>('https://localhost:5001/api/equipments')
    .then(response => setEquipments(response.data))

    return () => {};
  }, [])

  return (
    <>
      <Typography variant='h3'>ScanOps</Typography>
      <List>
        {equipments.map((Equipment) => (
          <ListItem key={Equipment.id}>
            <ListItemText>{Equipment.serialNumber}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  )
}

export default App
